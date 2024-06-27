using MediatR;
using RS.FleetAdmin.VesselAPI.Core.Application.Commands;
using RS.FleetAdmin.VesselAPI.Core.Application.Responses;
using RS.FleetAdmin.VesselAPI.Core.Application.Services;

namespace RS.FleetAdmin.VesselAPI.Core.Application.Handlers;

public class CreateVesselHandler(IVesselService vesselService)
    : IRequestHandler<CreateVesselCommand, VesselResponse>
{
    public async Task<VesselResponse> Handle(CreateVesselCommand command, CancellationToken cancellationToken)
    {
        var vessel = await vesselService.CreateVessel(command, cancellationToken);
        return vessel;
    }
}
