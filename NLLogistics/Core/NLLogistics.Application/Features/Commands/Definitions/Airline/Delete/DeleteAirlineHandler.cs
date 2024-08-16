using MediatR;
using NLLogistics.Application.Repositories.WriteRepositories.Definitions;
using Utilities.Core.UtilityApplication.Enums;

namespace NLLogistics.Application.Features.Commands.Definitions.Airline.Delete
{
    public class DeleteAirlineHandler : IRequestHandler<DeleteAirlineRequest, DeleteAirlineResponse>
    {
        readonly IAirlineWriteRepository _airlineWriteRepository;

        public DeleteAirlineHandler(IAirlineWriteRepository airlineWriteRepository)
        {
            _airlineWriteRepository = airlineWriteRepository;
        }

        public async Task<DeleteAirlineResponse> Handle(DeleteAirlineRequest request, CancellationToken cancellationToken)
        {
            await _airlineWriteRepository.SoftDeleteAsync(request.Id);
            await _airlineWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}