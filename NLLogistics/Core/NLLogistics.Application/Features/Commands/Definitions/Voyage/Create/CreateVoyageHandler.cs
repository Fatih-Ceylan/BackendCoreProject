using MediatR;
using NLLogistics.Application.Repositories.WriteRepositories.Definitions;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.NLLogistics.Definitions;

namespace NLLogistics.Application.Features.Commands.Definitions.Voyage.Create
{
    public class CreateVoyageHandler : IRequestHandler<CreateVoyageRequest, CreateVoyageResponse>
    {
        readonly IVoyageWriteRepository _voyageWriteRepository;

        public CreateVoyageHandler(IVoyageWriteRepository voyageWriteRepository)
        {
            _voyageWriteRepository = voyageWriteRepository;
        }

        public async Task<CreateVoyageResponse> Handle(CreateVoyageRequest request, CancellationToken cancellationToken)
        {
            T.Voyage voyage = new();
            voyage.VesselId = Guid.Parse(request.VesselId);
            voyage.Name = request.Name;

            voyage = await _voyageWriteRepository.AddAsync(voyage);
            await _voyageWriteRepository.SaveAsync();

            return new()
            {
                Id = voyage.Id.ToString(),
                VesselId = voyage.VesselId.ToString(),
                Name = voyage.Name,
                Message = CommandResponseMessage.AddedSuccess.ToString()
            };
        }
    }
}