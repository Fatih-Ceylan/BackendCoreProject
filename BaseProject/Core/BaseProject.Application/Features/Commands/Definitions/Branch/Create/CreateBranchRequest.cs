﻿using MediatR;

namespace BaseProject.Application.Features.Commands.Definitions.Branch.Create
{
    public class CreateBranchRequest : IRequest<CreateBranchResponse>
    {
        public string CompanyId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string? AuthorizedFullName { get; set; }

        public string? FullAddress { get; set; }

        public string? PostalCode { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public int? CountryId { get; set; }

        public int? CityId { get; set; }

        public int? DistrictId { get; set; }
    }
}