using MediatR;
using Platform.Application.Repositories.ReadRepository.Definitions;
using Platform.Application.VMs.Definitions.GModule;

namespace Platform.Application.Features.Queries.Definitions.GModule.GetAll
{
    public class GetAllGModuleHandler : IRequestHandler<GetAllGModuleRequest, GetAllGModuleResponse>
    {
        readonly IGModuleReadRepository _gmoduleReadRepository;

        public GetAllGModuleHandler(IGModuleReadRepository gmoduleReadRepository)
        {
            _gmoduleReadRepository = gmoduleReadRepository;
        }

        public async Task<GetAllGModuleResponse> Handle(GetAllGModuleRequest request, CancellationToken cancellationToken)
        {
            var query = _gmoduleReadRepository
                         .GetAllDeletedStatusDesc(false, request.IsDeleted)
                         .Select(gm => new GModuleVM
                         {
                             Id = gm.Id.ToString(),
                             Name = gm.Name,
                             LogoPath = gm.LogoPath,
                             CreatedDate = gm.CreatedDate,
                         });

            var totalCount = query.Count();
            var gmodules = request.DoPagination ? query.Skip(request.Page * request.Size)
                                                       .Take(request.Size).ToList()
                                                : query.ToList();

            return new()
            {
                TotalCount = totalCount,
                GModules = gmodules,
            };
        }
    }
}