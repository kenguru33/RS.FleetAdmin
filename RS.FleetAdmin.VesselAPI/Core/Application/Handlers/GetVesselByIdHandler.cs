using MediatR;
using RS.FleetAdmin.VesselAPI.Core.Application.Queries;
using RS.FleetAdmin.VesselAPI.Core.Application.Responses;
using RS.FleetAdmin.VesselAPI.Core.Application.Services;

namespace RS.FleetAdmin.VesselAPI.Core.Application.Handlers;

public class GetVesselByIdHandler(IVesselService vesselService) : IRequestHandler<GetVesselByIdQuery, VesselResponse>
{
    public async Task<VesselResponse> Handle(GetVesselByIdQuery request, CancellationToken cancellationToken)
    {
        var vessel = await vesselService.GetVesselById(request.VesselId, cancellationToken);
        return vessel;
    }
}