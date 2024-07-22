using RS.FleetAdmin.VesselAPI.Core.Application.Commands;
using RS.FleetAdmin.VesselAPI.Core.Application.Queries;
using RS.FleetAdmin.VesselAPI.Core.Application.Responses;

namespace RS.FleetAdmin.VesselAPI.Core.Application.Services;

public interface IVesselService
{
    public Task<VesselResponse> CreateVessel(CreateVesselCommand command, CancellationToken cancellationToken);
    
    Task<VesselResponse> GetVesselById(GetVesselByIdQuery query, CancellationToken cancellationToken);

    Task<List<VesselResponse>> GetVessels();
}