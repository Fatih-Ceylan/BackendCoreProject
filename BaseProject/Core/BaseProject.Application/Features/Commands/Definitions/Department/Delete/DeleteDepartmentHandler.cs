﻿using BaseProject.Application.Repositories.WriteRepository.Definitions;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace BaseProject.Application.Features.Commands.Definitions.Department.Delete
{
    public class DeleteDepartmentHandler : IRequestHandler<DeleteDepartmentRequest, DeleteDepartmentResponse>
    {
        readonly IDepartmentWriteRepository _departmentWriteRepository;

        public DeleteDepartmentHandler(IDepartmentWriteRepository departmentWriteRepository)
        {
            _departmentWriteRepository = departmentWriteRepository;
        }

        public async Task<DeleteDepartmentResponse> Handle(DeleteDepartmentRequest request, CancellationToken cancellationToken)
        {
            await _departmentWriteRepository.SoftDeleteAsync(request.Id);
            await _departmentWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}