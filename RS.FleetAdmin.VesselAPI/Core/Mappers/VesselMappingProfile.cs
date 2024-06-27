using AutoMapper;
using RS.FleetAdmin.Shared.Messaging.Messages;
using RS.FleetAdmin.VesselAPI.Core.Commands;
using RS.FleetAdmin.VesselAPI.Core.Responses;
using RS.FleetAdmin.VesselAPI.Entities;

namespace RS.FleetAdmin.VesselAPI.Core.Mappers;

public class VesselMappingProfile : Profile
{
    public VesselMappingProfile()
    {
        CreateMap<CreateVesselCommand, Vessel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.VesselId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.VesselName));
        CreateMap<Vessel, VesselResponse>()
            .ForMember(dest => dest.VesselId, opt => opt.MapFrom(src => src.Id.ToString()))
            .ForMember(dest => dest.VesselName, opt => opt.MapFrom(src => src.Name));
        CreateMap<Vessel, VesseLCreated>()
            .ForMember(dest => dest.VesselId, opt => opt.MapFrom(src => src.Id));
    }
}