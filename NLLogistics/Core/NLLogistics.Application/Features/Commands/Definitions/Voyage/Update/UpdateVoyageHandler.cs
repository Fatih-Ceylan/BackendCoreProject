using MediatR;
using NLLogistics.Application.Repositories.ReadRepositories.Definitions;
using NLLogistics.Application.Repositories.WriteRepositories.Definitions;
using Utilities.Core.UtilityApplication.Enums;

namespace NLLogistics.Application.Features.Commands.Definitions.Voyage.Update
{
    public class UpdateVoyageHandler : IRequestHandler<UpdateVoyageRequest, UpdateVoyageResponse>
    {
        readonly IVoyageReadRepository _voyageReadRepository;
        readonly IVoyageWriteRepository _voyageWriteRepository;

        public UpdateVoyageHandler(IVoyageReadRepository voyageReadRepository, IVoyageWriteRepository voyageWriteRepository)
        {
            _voyageReadRepository = voyageReadRepository;
            _voyageWriteRepository = voyageWriteRepository;
        }

        public async Task<UpdateVoyageResponse> Handle(UpdateVoyageRequest request, CancellationToken cancellationToken)
        {
            var voyage = await _voyageReadRepository.GetByIdAsync(request.Id);
            voyage.VesselId = Guid.Parse(request.VesselId);
            voyage.Name = request.Name;

            await _voyageWriteRepository.SaveAsync();

            return new()
            {
                Id = voyage.Id.ToString(),
                VesselId = voyage.VesselId.ToString(),
                Name = voyage.Name,
                Message = CommandResponseMessage.UpdatedSuccess.ToString()
            };
        }
    }
}