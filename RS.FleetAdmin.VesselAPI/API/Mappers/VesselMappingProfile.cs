using AutoMapper;
using RS.FleetAdmin.VesselAPI.API.DTOs;
using RS.FleetAdmin.VesselAPI.Core.Application.Commands;
using RS.FleetAdmin.VesselAPI.Core.Application.Responses;

namespace RS.FleetAdmin.VesselAPI.API.Mappers;

public class VesselMappingProfile : Profile
{
    public VesselMappingProfile()
    {
        CreateMap<CreateVesselDto, CreateVesselCommand>()
            .ForMember(dest => dest.VesselId, opt => opt.MapFrom(src => Guid.NewGuid()));
        CreateMap<VesselResponse, VesselResponseDto>();
    }
    
    
}