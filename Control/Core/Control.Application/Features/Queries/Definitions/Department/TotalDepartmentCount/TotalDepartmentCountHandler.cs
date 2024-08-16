using GControl.Application.Repositories.ReadRepository;
using MediatR;

namespace GControl.Application.Features.Queries.Definitions.Department.TotalDepartmentCount
{
    public class TotalDepartmentCountHandler : IRequestHandler<TotalDepartmentCountRequest, TotalDepartmentCountResponse>
    {
        readonly IDepartmentReadRepository _totalDepartmentCountReadRepository;

        public TotalDepartmentCountHandler(IDepartmentReadRepository totalDepartmentCountReadRepository)
        {
            _totalDepartmentCountReadRepository = totalDepartmentCountReadRepository;
        }

        public Task<TotalDepartmentCountResponse> Handle(TotalDepartmentCountRequest request, CancellationToken cancellationToken)
        {
            var query = _totalDepartmentCountReadRepository
                        .GetAllDeletedStatusDesc(false);
            //.Select(ds => new LocationVM
            //{
            //    Id = ds.Id.ToString(),
            //    Name = ds.Name,
            //    CreatedDate = ds.CreatedDate,
            //});

            var totalDepartmentCount = query.Count();
            //var totalLocationCountes = query.Skip(request.Page * request.Size)
            //.Take(request.Size).ToList();

            return Task.FromResult(new TotalDepartmentCountResponse
            {
                TotalDepartmentCount = totalDepartmentCount
            });
        }
    }
}
