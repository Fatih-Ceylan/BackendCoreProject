using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.Repositories.WriteRepository.Definitions;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace BaseProject.Application.Features.Commands.Definitions.City.Delete
{
    public class DeleteCityHandler : IRequestHandler<DeleteCityRequest, DeleteCityResponse>
    {
        readonly ICityReadRepository _cityReadRepository;
        readonly ICityWriteRepository _cityWriteRepository;

        public DeleteCityHandler(ICityWriteRepository cityWriteRepository, ICityReadRepository cityReadRepository)
        {
            _cityWriteRepository = cityWriteRepository;
            _cityReadRepository = cityReadRepository;
        }

        public async Task<DeleteCityResponse> Handle(DeleteCityRequest request, CancellationToken cancellationToken)
        {
            var city = _cityReadRepository.GetAll()
                                          .Where(c => c.Idc == request.Id).FirstOrDefault();

            if (city != null)
            {
                city.IsDeleted = true;
                await _cityWriteRepository.SaveAsync();

                return new()
                {
                    Message = CommandResponseMessage.DeletedSuccess.ToString()
                };
            }
            else
                throw new Exception("This city is not registered.");
            
        }
    }
}