using MediatR;
using RS.FleetAdmin.VesselAPI.Core.Application.Queries;
using RS.FleetAdmin.VesselAPI.Core.Application.Responses;
using RS.FleetAdmin.VesselAPI.Core.Application.Services;

namespace RS.FleetAdmin.VesselAPI.Core.Application.Handlers;

public class GetVesselsHandler(IVesselService vesselService) : IRequestHandler<GetVesselsQuery, List<VesselResponse>>
{
    public async Task<List<VesselResponse>> Handle(GetVesselsQuery request, CancellationToken cancellationToken)
    {
        var vessels = await vesselService.GetVessels();
        return vessels.ToList();
    }
}