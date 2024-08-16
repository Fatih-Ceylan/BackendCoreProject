using AutoMapper;
using Card.Application.Repositories.ReadRepository;
using Card.Application.Repositories.WriteRepository;
using Card.Application.VMs;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.Card.Definitions;

namespace Card.Application.Features.Commands.Definitions.StaffField.UpdateWithList
{
    public class UpdateWithListStaffFieldHandler : IRequestHandler<UpdateWithListStaffFieldRequest, UpdateWithListStaffFieldResponse>
    {
        readonly IStaffFieldReadRepository _staffFieldReadRepository;
        readonly IStaffFieldWriteRepository _staffFieldWriteRepository;
        readonly IMapper _mapper;

        public UpdateWithListStaffFieldHandler(IStaffFieldReadRepository staffFieldReadRepository, IStaffFieldWriteRepository staffFieldWriteRepository, IMapper mapper)
        {
            _staffFieldReadRepository = staffFieldReadRepository;
            _staffFieldWriteRepository = staffFieldWriteRepository;
            _mapper = mapper;
        }

        public async Task<UpdateWithListStaffFieldResponse> Handle(UpdateWithListStaffFieldRequest request, CancellationToken cancellationToken)
        {
            List<T.StaffField> staffFields = new List<T.StaffField>();

            foreach (var staffField in request.StaffFields)
            {
                T.StaffField field = await _staffFieldReadRepository.GetByIdAsync(staffField.Id);
                field = _mapper.Map(request, field);

                field.Id = Guid.Parse(staffField.Id);
                field.RowNumber = staffField.RowNumber;
                field.StaffId= Guid.Parse(staffField.StaffId);

                Guid branchId;
                if (Guid.TryParse(staffField.BranchId, out branchId))
                {
                    field.BranchId = branchId;
                }
                else
                {
                    field.BranchId = null; 
                }

                Guid companyId;
                if (Guid.TryParse(staffField.CompanyId, out companyId))
                {
                    field.CompanyId = companyId;
                }
                else
                {
                    field.CompanyId = null;
                } 

                staffFields.Add(field);
            }

            _staffFieldWriteRepository.UpdateRange(staffFields);
             

            await _staffFieldWriteRepository.SaveAsync();

            var updatedResponse = new UpdateWithListStaffFieldResponse
            {
                Message = CommandResponseMessage.UpdatedSuccess.ToString(),
                StaffFields = staffFields.Select(sf => new StaffFieldVM
                {
                    Id = sf.Id.ToString(),
                    FieldId = sf.FieldId.ToString(),
                    RowNumber = sf.RowNumber,
                    BranchId =sf.BranchId.ToString(),
                    CompanyId = sf.CompanyId.ToString(),
                    StaffId =sf.StaffId.ToString(),   

                }).ToList()

            };

            return updatedResponse;
        }
    }
}
