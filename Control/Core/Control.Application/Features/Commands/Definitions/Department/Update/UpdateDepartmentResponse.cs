﻿namespace GControl.Application.Features.Commands.Definitions.Department.Update
{
    public class UpdateDepartmentResponse
    {
        public string Id { get; set; }
        public string BaseDepartmentId { get; set; }
        public string BaseDepartmentName { get; set; }
        public string LocationId { get; set; }
        public string LocationName { get; set; }
        public bool? isActive { get; set; } 
        public string Message { get; set; }
    }
}
