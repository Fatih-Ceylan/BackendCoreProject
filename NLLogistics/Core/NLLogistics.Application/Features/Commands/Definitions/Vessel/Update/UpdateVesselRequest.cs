﻿using MediatR;

namespace NLLogistics.Application.Features.Commands.Definitions.Vessel.Update
{
    public class UpdateVesselRequest: IRequest<UpdateVesselResponse>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int CountryId { get; set; }

        public string Year { get; set; }

        public string Imo { get; set; }

        public string Link { get; set; }

    }
}
