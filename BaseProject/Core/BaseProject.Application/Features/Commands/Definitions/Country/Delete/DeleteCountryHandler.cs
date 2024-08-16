using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.Repositories.WriteRepository.Definitions;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace BaseProject.Application.Features.Commands.Definitions.Country.Delete
{
    public class DeleteCountryHandler : IRequestHandler<DeleteCountryRequest, DeleteCountryResponse>
    {
        readonly ICountryWriteRepository _countryWriteRepository;
        readonly ICountryReadRepository _countryReadRepository;

        public DeleteCountryHandler(ICountryWriteRepository countryWriteRepository, ICountryReadRepository countryReadRepository)
        {
            _countryWriteRepository = countryWriteRepository;
            _countryReadRepository = countryReadRepository;
        }

        public async Task<DeleteCountryResponse> Handle(DeleteCountryRequest request, CancellationToken cancellationToken)
        {
            var country = _countryReadRepository.GetAll()
                                                .Where(c => c.Idc == request.Id).FirstOrDefault();
            if (country != null) { 
                country.IsDeleted = true;
                await _countryWriteRepository.SaveAsync();

                return new()
                {
                    Message = CommandResponseMessage.DeletedSuccess.ToString(),
                };
            }
            else
                throw new Exception("This country is not registered.");

        }
    }
}
