using MediatR;
using NLLogistics.Application.Repositories.ReadRepositories.Definitions;
using NLLogistics.Application.Repositories.WriteRepositories.Definitions;
using Utilities.Core.UtilityApplication.Enums;

namespace NLLogistics.Application.Features.Commands.Definitions.Airport.Update
{
    public class UpdateAirportHandler : IRequestHandler<UpdateAirportRequest, UpdateAirportResponse>
    {
        readonly IAirportReadRepository _airportReadRepository;
        readonly IAirportWriteRepository _airportWriteRepository;

        public UpdateAirportHandler(IAirportReadRepository airportReadRepository, IAirportWriteRepository airportWriteRepository)
        {
            _airportReadRepository = airportReadRepository;
            _airportWriteRepository = airportWriteRepository;
        }

        public async Task<UpdateAirportResponse> Handle(UpdateAirportRequest request, CancellationToken cancellationToken)
        {
            var airport = await _airportReadRepository.GetByIdAsync(request.Id);
            airport.Code = request.Code;
            airport.Name = request.Name;
            airport.CountryId = request.CountryId;

            await _airportWriteRepository.SaveAsync();

            return new()
            {
                Id = airport.Id.ToString(),
                Code = airport.Code,
                Name = airport.Name,
                Message = CommandResponseMessage.UpdatedSuccess.ToString()
            };
        }
    }
}