using MediatR;
using NLLogistics.Application.Repositories.WriteRepositories.Definitions;
using Utilities.Core.UtilityApplication.Enums;

namespace NLLogistics.Application.Features.Commands.Definitions.Vessel.Delete
{
    public class DeleteVesselHandler : IRequestHandler<DeleteVesselRequest, DeleteVesselResponse>
    {
        readonly IVesselWriteRepository _vesselWriteRepository;

        public DeleteVesselHandler(IVesselWriteRepository vesselWriteRepository)
        {
            _vesselWriteRepository = vesselWriteRepository;
        }

        public async Task<DeleteVesselResponse> Handle(DeleteVesselRequest request, CancellationToken cancellationToken)
        {
            await _vesselWriteRepository.SoftDeleteAsync(request.Id);
            await _vesselWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}