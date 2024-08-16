using AutoMapper;
using Card.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.Card.Definitions;

namespace Card.Application.Features.Commands.Definitions.StaffField.Create
{
    public class CreateStaffFieldHandler : IRequestHandler<CreateStaffFieldRequest, CreateStaffFieldResponse>
    {
        readonly IStaffFieldWriteRepository _staffFieldWriteRepository;
        readonly IMapper _mapper;

        public CreateStaffFieldHandler(IStaffFieldWriteRepository staffFieldWriteRepository, IMapper mapper)
        {
            _staffFieldWriteRepository = staffFieldWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateStaffFieldResponse> Handle(CreateStaffFieldRequest request, CancellationToken cancellationToken)
        {
            var staffField = _mapper.Map<T.StaffField>(request);

            staffField = await _staffFieldWriteRepository.AddAsync(staffField);

            await _staffFieldWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateStaffFieldResponse>(staffField);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
