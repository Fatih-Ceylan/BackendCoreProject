using MediatR;
using NLLogistics.Application.Repositories.WriteRepositories.Definitions;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.NLLogistics.Definitions;

namespace NLLogistics.Application.Features.Commands.Definitions.Airport.Create
{
    public class CreateAirportHandler : IRequestHandler<CreateAirportRequest, CreateAirportResponse>
    {
        readonly IAirportWriteRepository _airportWriteRepository;

        public CreateAirportHandler(IAirportWriteRepository airportWriteRepository)
        {
            _airportWriteRepository = airportWriteRepository;
        }

        public async Task<CreateAirportResponse> Handle(CreateAirportRequest request, CancellationToken cancellationToken)
        {
            T.Airport airport = new();
            airport.Code = request.Code;
            airport.Name = request.Name;
            airport.CountryId = request.CountryId;

            airport = await _airportWriteRepository.AddAsync(airport);
            await _airportWriteRepository.SaveAsync();

            return new()
            {
                Id = airport.Id.ToString(),
                Code = airport.Code,
                Name = airport.Name,
                Message = CommandResponseMessage.AddedSuccess.ToString()
            };
        }
    }
}
