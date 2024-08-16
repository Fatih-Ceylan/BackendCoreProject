using AutoMapper;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.VMs.Definitions;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace GControl.Application.Features.Queries.Definitions.EmployeeLabel.GetAll
{
    public class GetAllEmployeeLabelHandler : IRequestHandler<GetAllEmployeeLabelRequest, GetAllEmployeeLabelResponse>
    {
        private readonly IMapper _mapper;
        readonly IEmployeeLabelReadRepository _employeeLabelReadRepository;
        readonly IEmployeeReadRepository _employeeReadRepository;

        public GetAllEmployeeLabelHandler(IEmployeeLabelReadRepository employeeLabelReadRepository, IEmployeeReadRepository employeeReadRepository, IMapper mapper)
        {
            _employeeReadRepository = employeeReadRepository;
            _employeeLabelReadRepository = employeeLabelReadRepository;
            _mapper = mapper;
        }

        public async Task<GetAllEmployeeLabelResponse> Handle(GetAllEmployeeLabelRequest request, CancellationToken cancellationToken)
        {
            var employeeQuery = _employeeReadRepository.GetAllDeletedStatusDesc(false, request.IsDeleted);
            var labelQuery = _employeeLabelReadRepository.GetAllDeletedStatusDesc(false, request.IsDeleted);

            var employeeLabels = await labelQuery.Select(label => new EmployeeLabelVM
            {
                Id = label.Id.ToString(),
                Name = label.Name,
                CreatedDate = label.CreatedDate,
                UpdatedDate = label.UpdatedDate
            }).ToListAsync();


            foreach (var label in employeeLabels)
            {
                label.EmployeeCount = await employeeQuery.CountAsync(employee => employee.EmployeeLabels.Any(el => el.Id == Guid.Parse(label.Id)));
            }

            var totalCount = employeeLabels.Count;

            var filteredQuery = employeeLabels.AsQueryable();
            if (!string.IsNullOrEmpty(request.FilterText))
            {
                filteredQuery = filteredQuery.Where(x =>
                    x.Name.Contains(request.FilterText)
                );
                totalCount = filteredQuery.Count();
            }
            var labels = _mapper.Map<List<EmployeeLabelVM>>(filteredQuery);



            return new GetAllEmployeeLabelResponse
            {
                TotalCount = totalCount,
                EmployeeLabels = labels,
            };
        }
    }

    }

