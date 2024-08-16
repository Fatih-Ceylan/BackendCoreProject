using MediatR;
using NLLogistics.Application.Repositories.WriteRepositories.Definitions;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.NLLogistics.Definitions;

namespace NLLogistics.Application.Features.Commands.Definitions.Airline.Create
{
    public class CreateAirlineHandler : IRequestHandler<CreateAirlineRequest, CreateAirlineResponse>
    {
        readonly IAirlineWriteRepository _airlineWriteRepository;

        public CreateAirlineHandler(IAirlineWriteRepository airlineWriteRepository)
        {
            _airlineWriteRepository = airlineWriteRepository;
        }

        public async Task<CreateAirlineResponse> Handle(CreateAirlineRequest request, CancellationToken cancellationToken)
        {
            T.Airline airline = new();
            airline.Code = request.Code;
            airline.Name = request.Name;
            airline.CountryId = request.CountryId;

            airline = await _airlineWriteRepository.AddAsync(airline);
            await _airlineWriteRepository.SaveAsync();

            return new()
            {
                Id = airline.Id.ToString(),
                Code = airline.Code,
                Name = airline.Name,
                Message = CommandResponseMessage.AddedSuccess.ToString()
            };
        }
    }
}
