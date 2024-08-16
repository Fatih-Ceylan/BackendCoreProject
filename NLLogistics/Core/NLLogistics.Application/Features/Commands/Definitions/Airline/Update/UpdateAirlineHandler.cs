using MediatR;
using NLLogistics.Application.Repositories.ReadRepositories.Definitions;
using NLLogistics.Application.Repositories.WriteRepositories.Definitions;
using Utilities.Core.UtilityApplication.Enums;

namespace NLLogistics.Application.Features.Commands.Definitions.Airline.Update
{
    public class UpdateAirlineHandler : IRequestHandler<UpdateAirlineRequest, UpdateAirlineResponse>
    {
        readonly IAirlineReadRepository _airlineReadRepository;
        readonly IAirlineWriteRepository _airlineWriteRepository;

        public UpdateAirlineHandler(IAirlineReadRepository airlineReadRepository, IAirlineWriteRepository airlineWriteRepository)
        {
            _airlineReadRepository = airlineReadRepository;
            _airlineWriteRepository = airlineWriteRepository;
        }

        public async Task<UpdateAirlineResponse> Handle(UpdateAirlineRequest request, CancellationToken cancellationToken)
        {
            var airline = await _airlineReadRepository.GetByIdAsync(request.Id);
            airline.Code = request.Code;
            airline.Name = request.Name;
            airline.CountryId = request.CountryId;

            await _airlineWriteRepository.SaveAsync();

            return new()
            {
                Id = airline.Id.ToString(),
                Code = airline.Code,
                Name = airline.Name,
                Message = CommandResponseMessage.UpdatedSuccess.ToString()
            };
        }
    }
}