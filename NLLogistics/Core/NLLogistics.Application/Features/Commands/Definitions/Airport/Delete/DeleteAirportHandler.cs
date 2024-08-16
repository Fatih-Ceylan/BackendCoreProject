using MediatR;
using NLLogistics.Application.Repositories.WriteRepositories.Definitions;
using Utilities.Core.UtilityApplication.Enums;

namespace NLLogistics.Application.Features.Commands.Definitions.Airport.Delete
{
    public class DeleteAirportHandler : IRequestHandler<DeleteAirportRequest, DeleteAirportResponse>
    {
        readonly IAirportWriteRepository _airportWriteRepository;

        public DeleteAirportHandler(IAirportWriteRepository airportWriteRepository)
        {
            _airportWriteRepository = airportWriteRepository;
        }

        public async Task<DeleteAirportResponse> Handle(DeleteAirportRequest request, CancellationToken cancellationToken)
        {
            await _airportWriteRepository.SoftDeleteAsync(request.Id);
            await _airportWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}