using AutoMapper;
using BaseProject.Domain.Entities.NLLogistics.Definitions;
using NLLogistics.Application.Features.Commands.Definitions.Vessel.Create;
using NLLogistics.Application.Features.Commands.Definitions.Vessel.Update;

namespace NLLogistics.Application.Models
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            #region Vessel
            CreateMap<Vessel, CreateVesselRequest>().ReverseMap();
            CreateMap<CreateVesselResponse, Vessel>().ReverseMap();
            CreateMap<UpdateVesselRequest, Vessel>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<Vessel, UpdateVesselResponse>().ReverseMap();
            #endregion
        }
    }
}