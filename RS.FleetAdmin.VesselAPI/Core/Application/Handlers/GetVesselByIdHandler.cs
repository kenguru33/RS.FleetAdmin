using MediatR;
using RS.FleetAdmin.VesselAPI.Core.Application.Queries;
using RS.FleetAdmin.VesselAPI.Core.Application.Responses;
using RS.FleetAdmin.VesselAPI.Core.Application.Services;

namespace RS.FleetAdmin.VesselAPI.Core.Application.Handlers;

public class GetVesselByIdHandler(IVesselService vesselService) : IRequestHandler<GetVesselByIdQuery, VesselResponse>
{
    public async Task<VesselResponse> Handle(GetVesselByIdQuery query, CancellationToken cancellationToken)
    {
        var vessel = await vesselService.GetVesselById(query, cancellationToken);
        return vessel;
    }
}