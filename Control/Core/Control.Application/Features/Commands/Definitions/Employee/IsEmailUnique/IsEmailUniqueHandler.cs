using GControl.Application.Repositories.ReadRepository;
using MediatR;

namespace GControl.Application.Features.Commands.Definitions.Employee.IsEmailUnique
{
    public class IsEmailUniqueHandler : IRequestHandler<IsEmailUniqueRequest, IsEmailUniqueResponse>
    {
        readonly IEmployeeReadRepository _employeeReadRepository;

        public IsEmailUniqueHandler(IEmployeeReadRepository employeeReadRepository)
        {
            _employeeReadRepository = employeeReadRepository;
        }

        public async Task<IsEmailUniqueResponse> Handle(IsEmailUniqueRequest request, CancellationToken cancellationToken)
        {

            var existingEmployeeEmail = _employeeReadRepository.GetWhere(l => l.Email == request.Email).FirstOrDefault();

            if (existingEmployeeEmail != null)
            {
                var warningResponse = new IsEmailUniqueResponse
                {
                    Message = "Bu isimde bir email zaten mevcut",
                    Status = false
                };
                return warningResponse;
            }
            else
            {
                var successResponse = new IsEmailUniqueResponse
                {
                    Message = "",
                    Status = true
                };
                return successResponse;
            }
        }
    }
}
